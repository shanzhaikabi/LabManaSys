import request from 'umi-request';
import { IPostClaimFormParam } from 'umi';

export async function submitClaimForm(params: IPostClaimFormParam) {
  return request('/api/form/claim', {
    method: 'POST',
    data: params,
  });
}
